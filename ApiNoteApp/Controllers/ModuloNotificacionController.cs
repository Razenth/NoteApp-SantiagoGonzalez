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
public class ModuloNotificacionController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloNotificacionDto>>> Get()
    {
        var moduloNotificaciones = await _unitOfWork.ModulosNotificaciones.GetAllAsync();
        return _mapper.Map<List<ModuloNotificacionDto>>(moduloNotificaciones);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionDto>> Get(int id)
    {
        var moduloNotificacion = await _unitOfWork.ModulosNotificaciones.GetByIdAsync(id);

        if (moduloNotificacion == null)
        {
            return NotFound();
        }

        return _mapper.Map<ModuloNotificacionDto>(moduloNotificacion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloNotificacion>> Post(ModuloNotificacionDto ModuloNotificacionDto)
    {
        var moduloNotificaciones = _mapper.Map<ModuloNotificacion>(ModuloNotificacionDto);
        this._unitOfWork.ModulosNotificaciones.Add(moduloNotificaciones);
        await _unitOfWork.SaveAsync();

        if (moduloNotificaciones == null)
        {
            return BadRequest();
        }
        ModuloNotificacionDto.Id = moduloNotificaciones.Id;
        return CreatedAtAction(nameof(Post), new { id = ModuloNotificacionDto.Id }, ModuloNotificacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionDto>> Put(int id, [FromBody] ModuloNotificacionDto ModuloNotificacionDto)
    {
        if (ModuloNotificacionDto.Id == 0)
        {
            ModuloNotificacionDto.Id = id;
        }

        if (ModuloNotificacionDto.Id != id)
        {
            return BadRequest();
        }

        if (ModuloNotificacionDto == null)
        {
            return NotFound();
        }

        if (ModuloNotificacionDto.FechaModificacion == DateTime.MinValue)
        {
            ModuloNotificacionDto.FechaModificacion = DateTime.Now;
        }

        var moduloNotificacion = _mapper.Map<ModuloNotificacion>(ModuloNotificacionDto);
        _unitOfWork.ModulosNotificaciones.Update(moduloNotificacion);
        await _unitOfWork.SaveAsync();
        return ModuloNotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var moduloNotificacion = await _unitOfWork.ModulosNotificaciones.GetByIdAsync(id);

        if (moduloNotificacion == null)
        {
            return NotFound();
        }

        _unitOfWork.ModulosNotificaciones.Remove(moduloNotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
