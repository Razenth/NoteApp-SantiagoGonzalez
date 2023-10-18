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
public class HiloRespuestaNotificacionController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HiloRespuestaNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<HiloRespuestaNotificacionDto>>> Get()
    {
        var hiloRespuestas = await _unitOfWork.HiloRepuestaNotificaciones.GetAllAsync();
        return _mapper.Map<List<HiloRespuestaNotificacionDto>>(hiloRespuestas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HiloRespuestaNotificacionDto>> Get(int id)
    {
        var hiloRespuesta = await _unitOfWork.HiloRepuestaNotificaciones.GetByIdAsync(id);

        if (hiloRespuesta == null)
        {
            return NotFound();
        }

        return _mapper.Map<HiloRespuestaNotificacionDto>(hiloRespuesta);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HiloRespuestaNotificacion>> Post(HiloRespuestaNotificacionDto HiloRespuestaNotificacionDto)
    {
        var hiloRespuestas = _mapper.Map<HiloRespuestaNotificacion>(HiloRespuestaNotificacionDto);
        this._unitOfWork.HiloRepuestaNotificaciones.Add(hiloRespuestas);
        await _unitOfWork.SaveAsync();

        if (hiloRespuestas == null)
        {
            return BadRequest();
        }
        HiloRespuestaNotificacionDto.Id = hiloRespuestas.Id;
        return CreatedAtAction(nameof(Post), new { id = HiloRespuestaNotificacionDto.Id }, HiloRespuestaNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HiloRespuestaNotificacionDto>> Put(int id, [FromBody] HiloRespuestaNotificacionDto HiloRespuestaNotificacionDto)
    {
        if (HiloRespuestaNotificacionDto.Id == 0)
        {
            HiloRespuestaNotificacionDto.Id = id;
        }

        if (HiloRespuestaNotificacionDto.Id != id)
        {
            return BadRequest();
        }

        if (HiloRespuestaNotificacionDto == null)
        {
            return NotFound();
        }

        if (HiloRespuestaNotificacionDto.FechaModificacion == DateTime.MinValue)
        {
            HiloRespuestaNotificacionDto.FechaModificacion = DateTime.Now;
        }

        var hiloRespuesta = _mapper.Map<HiloRespuestaNotificacion>(HiloRespuestaNotificacionDto);
        _unitOfWork.HiloRepuestaNotificaciones.Update(hiloRespuesta);
        await _unitOfWork.SaveAsync();
        return HiloRespuestaNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var hiloRespuesta = await _unitOfWork.HiloRepuestaNotificaciones.GetByIdAsync(id);

        if (hiloRespuesta == null)
        {
            return NotFound();
        }

        _unitOfWork.HiloRepuestaNotificaciones.Remove(hiloRespuesta);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}