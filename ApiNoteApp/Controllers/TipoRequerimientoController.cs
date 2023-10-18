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

public class TipoRequerimientoController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
    {
        var tiposRequerimientos = await _unitOfWork.TipoRequerimientos.GetAllAsync();
        return _mapper.Map<List<TipoRequerimientoDto>>(tiposRequerimientos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Get(int id)
    {
        var tipoRequerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);

        if (tipoRequerimiento == null)
        {
            return NotFound();
        }

        return _mapper.Map<TipoRequerimientoDto>(tipoRequerimiento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoRequerimiento>> Post(TipoRequerimientoDto TipoRequerimientoDto)
    {
        var tiposRequerimientos = _mapper.Map<TipoRequerimiento>(TipoRequerimientoDto);
        this._unitOfWork.TipoRequerimientos.Add(tiposRequerimientos);
        await _unitOfWork.SaveAsync();

        if (tiposRequerimientos == null)
        {
            return BadRequest();
        }
        TipoRequerimientoDto.Id = tiposRequerimientos.Id;
        return CreatedAtAction(nameof(Post), new { id = TipoRequerimientoDto.Id }, TipoRequerimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto TipoRequerimientoDto)
    {
        if (TipoRequerimientoDto.Id == 0)
        {
            TipoRequerimientoDto.Id = id;
        }

        if (TipoRequerimientoDto.Id != id)
        {
            return BadRequest();
        }

        if (TipoRequerimientoDto == null)
        {
            return NotFound();
        }

        var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(TipoRequerimientoDto);
        _unitOfWork.TipoRequerimientos.Update(tipoRequerimiento);
        await _unitOfWork.SaveAsync();
        return TipoRequerimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoRequerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);

        if (tipoRequerimiento == null)
        {
            return NotFound();
        }

        _unitOfWork.TipoRequerimientos.Remove(tipoRequerimiento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
