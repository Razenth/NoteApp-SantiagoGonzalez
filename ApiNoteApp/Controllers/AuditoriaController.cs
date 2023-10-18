using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoteApp.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoteApp.Controllers;

public class AuditoriaController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
    {
        var auditorias = await _unitOfWork.Auditorias.GetAllAsync();
        return _mapper.Map<List<AuditoriaDto>>(auditorias);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<AuditoriaDto>> Get(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if(auditoria == null)
        {
            return NotFound();
        }
        return _mapper.Map<AuditoriaDto>(auditoria);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Auditoria>> Post(AuditoriaDto auditoriaDto)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
        _unitOfWork.Auditorias.Add(auditoria);
        await _unitOfWork.SaveAsync();
        if(auditoria == null)
        {
            return BadRequest();
        }
        if (auditoria.FechaCreacion == DateTime.MinValue){
            auditoria.FechaCreacion = DateTime.Now;
        }
        auditoriaDto.Id = auditoria.Id;
        return CreatedAtAction(nameof(Post), new {id = auditoriaDto.Id}, auditoriaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
    {
        if(auditoriaDto == null)
        {
            return NotFound();
        }
        if(auditoriaDto.Id == 0)
        {
            auditoriaDto.Id = id;
        }
        if(auditoriaDto.Id != id)
        {
            return BadRequest();
        }
        auditoriaDto.FechaCreacion = auditoriaDto.FechaCreacion;
        auditoriaDto.FechaModificacion = DateTime.Now;
        var audiMapeado = _mapper.Map<Auditoria>(auditoriaDto);
        _unitOfWork.Auditorias.Update(audiMapeado);
        await _unitOfWork.SaveAsync();
        return auditoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if(auditoria == null)
        {
            return NotFound();
        }
        _unitOfWork.Auditorias.Remove(auditoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
