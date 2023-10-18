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

public class RolVsMaestroController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolVsMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolVsMaestroDto>>> Get()
    {
        var rolMaestros = await _unitOfWork.RolesVsMaestro.GetAllAsync();
        return _mapper.Map<List<RolVsMaestroDto>>(rolMaestros);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Get(int id)
    {
        var rolMaestro = await _unitOfWork.RolesVsMaestro.GetByIdAsync(id);

        if (rolMaestro == null)
        {
            return NotFound();
        }

        return _mapper.Map<RolVsMaestroDto>(rolMaestro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestro>> Post(RolVsMaestroDto RolVsMaestroDto)
    {
        var rolMaestros = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        this._unitOfWork.RolesVsMaestro.Add(rolMaestros);
        await _unitOfWork.SaveAsync();

        if (rolMaestros == null)
        {
            return BadRequest();
        }
        RolVsMaestroDto.Id = rolMaestros.Id;
        return CreatedAtAction(nameof(Post), new { id = RolVsMaestroDto.Id }, RolVsMaestroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Put(int id, [FromBody] RolVsMaestroDto RolVsMaestroDto)
    {
        if (RolVsMaestroDto.Id == 0)
        {
            RolVsMaestroDto.Id = id;
        }

        if (RolVsMaestroDto.Id != id)
        {
            return BadRequest();
        }

        if (RolVsMaestroDto == null)
        {
            return NotFound();
        }

        if (RolVsMaestroDto.FechaModificacion == DateTime.MinValue)
        {
            RolVsMaestroDto.FechaModificacion = DateTime.Now;
        }

        var rolMaestro = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        _unitOfWork.RolesVsMaestro.Update(rolMaestro);
        await _unitOfWork.SaveAsync();
        return RolVsMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rolMaestro = await _unitOfWork.RolesVsMaestro.GetByIdAsync(id);

        if (rolMaestro == null)
        {
            return NotFound();
        }

        _unitOfWork.RolesVsMaestro.Remove(rolMaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
