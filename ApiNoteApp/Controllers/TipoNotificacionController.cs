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

public class TipoNotificacionController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoNotificacionDto>>> Get()
    {
        var tipoNotificaciones = await _unitOfWork.TipoNotificaciones.GetAllAsync();
        return _mapper.Map<List<TipoNotificacionDto>>(tipoNotificaciones);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNotificacionDto>> Get(int id)
    {
        var tipoNotificacion = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);

        if (tipoNotificacion == null)
        {
            return NotFound();
        }

        return _mapper.Map<TipoNotificacionDto>(tipoNotificacion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNotificacion>> Post(TipoNotificacionDto TipoNotificacionDto)
    {
        var tipoNotificacion = _mapper.Map<TipoNotificacion>(TipoNotificacionDto);
        this._unitOfWork.TipoNotificaciones.Add(tipoNotificacion);
        await _unitOfWork.SaveAsync();

        if (tipoNotificacion == null)
        {
            return BadRequest();
        }
        TipoNotificacionDto.Id = tipoNotificacion.Id;
        return CreatedAtAction(nameof(Post), new { id = TipoNotificacionDto.Id }, TipoNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNotificacionDto>> Put(int id, [FromBody] TipoNotificacionDto TipoNotificacionDto)
    {
        if (TipoNotificacionDto.Id == 0)
        {
            TipoNotificacionDto.Id = id;
        }

        if (TipoNotificacionDto.Id != id)
        {
            return BadRequest();
        }

        if (TipoNotificacionDto == null)
        {
            return NotFound();
        }

        if (TipoNotificacionDto.FechaModificacion == DateTime.MinValue)
        {
            TipoNotificacionDto.FechaModificacion = DateTime.Now;
        }

        var tipoNotificaciones = _mapper.Map<TipoNotificacion>(TipoNotificacionDto);
        _unitOfWork.TipoNotificaciones.Update(tipoNotificaciones);
        await _unitOfWork.SaveAsync();
        return TipoNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoNotificacion = await _unitOfWork.TipoNotificaciones.GetByIdAsync(id);

        if (tipoNotificacion == null)
        {
            return NotFound();
        }

        _unitOfWork.TipoNotificaciones.Remove(tipoNotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
