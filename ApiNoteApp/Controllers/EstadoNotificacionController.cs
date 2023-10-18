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

public class EstadoNotificacionController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EstadoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EstadoNotificacionDto>>> Get()
    {
        var estadoNotificaciones = await _unitOfWork.EstadoNotificaciones.GetAllAsync();
        return _mapper.Map<List<EstadoNotificacionDto>>(estadoNotificaciones);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoNotificacionDto>> Get(int id)
    {
        var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);

        if (estadoNotificacion == null)
        {
            return NotFound();
        }

        return _mapper.Map<EstadoNotificacionDto>(estadoNotificacion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EstadoNotificacion>> Post(EstadoNotificacionDto EstadoNotificacionDto)
    {
        var estadoNotificacion = _mapper.Map<EstadoNotificacion>(EstadoNotificacionDto);
        this._unitOfWork.EstadoNotificaciones.Add(estadoNotificacion);
        await _unitOfWork.SaveAsync();

        if (estadoNotificacion == null)
        {
            return BadRequest();
        }
        EstadoNotificacionDto.Id = estadoNotificacion.Id;
        return CreatedAtAction(nameof(Post), new { id = EstadoNotificacionDto.Id }, EstadoNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoNotificacionDto>> Put(int id, [FromBody] EstadoNotificacionDto EstadoNotificacionDto)
    {
        if (EstadoNotificacionDto.Id == 0)
        {
            EstadoNotificacionDto.Id = id;
        }

        if (EstadoNotificacionDto.Id != id)
        {
            return BadRequest();
        }

        if (EstadoNotificacionDto == null)
        {
            return NotFound();
        }

        var estadoNotificacion = _mapper.Map<EstadoNotificacion>(EstadoNotificacionDto);
        _unitOfWork.EstadoNotificaciones.Update(estadoNotificacion);
        await _unitOfWork.SaveAsync();
        return EstadoNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);

        if (estadoNotificacion == null)
        {
            return NotFound();
        }

        _unitOfWork.EstadoNotificaciones.Remove(estadoNotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
