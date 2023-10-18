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

public class ModuloMaestroController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloMaestroDto>>> Get()
    {
        var modulosMaestros = await _unitOfWork.ModulosMaestros.GetAllAsync();
        return _mapper.Map<List<ModuloMaestroDto>>(modulosMaestros);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloMaestroDto>> Get(int id)
    {
        var moduloMaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);

        if (moduloMaestro == null)
        {
            return NotFound();
        }

        return _mapper.Map<ModuloMaestroDto>(moduloMaestro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloMaestro>> Post(ModuloMaestroDto ModuloMaestroDto)
    {
        var moduloMaestros = _mapper.Map<ModuloMaestro>(ModuloMaestroDto);
        this._unitOfWork.ModulosMaestros.Add(moduloMaestros);
        await _unitOfWork.SaveAsync();

        if (moduloMaestros == null)
        {
            return BadRequest();
        }
        ModuloMaestroDto.Id = moduloMaestros.Id;
        return CreatedAtAction(nameof(Post), new { id = ModuloMaestroDto.Id }, ModuloMaestroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloMaestroDto>> Put(int id, [FromBody] ModuloMaestroDto ModuloMaestroDto)
    {
        if (ModuloMaestroDto.Id == 0)
        {
            ModuloMaestroDto.Id = id;
        }

        if (ModuloMaestroDto.Id != id)
        {
            return BadRequest();
        }

        if (ModuloMaestroDto == null)
        {
            return NotFound();
        }

        if (ModuloMaestroDto.FechaModificacion == DateTime.MinValue)
        {
            ModuloMaestroDto.FechaModificacion = DateTime.Now;
        }

        var moduloMaestros = _mapper.Map<ModuloMaestro>(ModuloMaestroDto);
        _unitOfWork.ModulosMaestros.Update(moduloMaestros);
        await _unitOfWork.SaveAsync();
        return ModuloMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var moduloMaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);

        if (moduloMaestro == null)
        {
            return NotFound();
        }

        _unitOfWork.ModulosMaestros.Remove(moduloMaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}