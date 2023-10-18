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
public class PermisoGenericoController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermisoGenericoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PermisoGenericoDto>>> Get()
    {
        var permisosGenericos = await _unitOfWork.PermisosGenericos.GetAllAsync();
        return _mapper.Map<List<PermisoGenericoDto>>(permisosGenericos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisoGenericoDto>> Get(int id)
    {
        var permisoGenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);

        if (permisoGenerico == null)
        {
            return NotFound();
        }

        return _mapper.Map<PermisoGenericoDto>(permisoGenerico);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisoGenerico>> Post(PermisoGenericoDto PermisoGenericoDto)
    {
        var permisoGenericos = _mapper.Map<PermisoGenerico>(PermisoGenericoDto);
        this._unitOfWork.PermisosGenericos.Add(permisoGenericos);
        await _unitOfWork.SaveAsync();

        if (permisoGenericos == null)
        {
            return BadRequest();
        }
        PermisoGenericoDto.Id = permisoGenericos.Id;
        return CreatedAtAction(nameof(Post), new { id = PermisoGenericoDto.Id }, PermisoGenericoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisoGenericoDto>> Put(int id, [FromBody] PermisoGenericoDto PermisoGenericoDto)
    {
        if (PermisoGenericoDto.Id == 0)
        {
            PermisoGenericoDto.Id = id;
        }

        if (PermisoGenericoDto.Id != id)
        {
            return BadRequest();
        }

        if (PermisoGenericoDto == null)
        {
            return NotFound();
        }

        if (PermisoGenericoDto.FechaModificacion == DateTime.MinValue)
        {
            PermisoGenericoDto.FechaModificacion = DateTime.Now;
        }

        var permisoGenerico = _mapper.Map<PermisoGenerico>(PermisoGenericoDto);
        _unitOfWork.PermisosGenericos.Update(permisoGenerico);
        await _unitOfWork.SaveAsync();
        return PermisoGenericoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var permisoGenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);

        if (permisoGenerico == null)
        {
            return NotFound();
        }

        _unitOfWork.PermisosGenericos.Remove(permisoGenerico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
