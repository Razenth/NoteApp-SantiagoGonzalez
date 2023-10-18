using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoteApp.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoteApp.Controllers;
public class RadicadoController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RadicadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RadicadoDto>>> Get()
    {
        var radicados = await _unitOfWork.Radicados.GetAllAsync();
        return _mapper.Map<List<RadicadoDto>>(radicados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RadicadoDto>> Get(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);

        if (radicado == null)
        {
            return NotFound();
        }

        return _mapper.Map<RadicadoDto>(radicado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Radicado>> Post(RadicadoDto RadicadoDto)
    {
        var radicados = _mapper.Map<Radicado>(RadicadoDto);
        this._unitOfWork.Radicados.Add(radicados);
        await _unitOfWork.SaveAsync();

        if (radicados == null)
        {
            return BadRequest();
        }
        RadicadoDto.Id = radicados.Id;
        return CreatedAtAction(nameof(Post), new { id = RadicadoDto.Id }, RadicadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RadicadoDto>> Put(int id, [FromBody] RadicadoDto RadicadoDto)
    {
        if (RadicadoDto.Id == 0)
        {
            RadicadoDto.Id = id;
        }

        if (RadicadoDto.Id != id)
        {
            return BadRequest();
        }

        if (RadicadoDto == null)
        {
            return NotFound();
        }

        if (RadicadoDto.FechaModificacion == DateTime.MinValue)
        {
            RadicadoDto.FechaModificacion = DateTime.Now;
        }

        var radicados = _mapper.Map<Radicado>(RadicadoDto);
        _unitOfWork.Radicados.Update(radicados);
        await _unitOfWork.SaveAsync();
        return RadicadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);

        if (radicado == null)
        {
            return NotFound();
        }

        _unitOfWork.Radicados.Remove(radicado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
