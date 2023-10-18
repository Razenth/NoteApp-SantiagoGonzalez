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
public class FormatoController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FormatoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FormatoDto>>> Get()
    {
        var formatos = await _unitOfWork.Formatos.GetAllAsync();
        return _mapper.Map<List<FormatoDto>>(formatos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatoDto>> Get(int id)
    {
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);

        if (formato == null)
        {
            return NotFound();
        }

        return _mapper.Map<FormatoDto>(formato);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Formato>> Post(FormatoDto FormatoDto)
    {
        var formatos = _mapper.Map<Formato>(FormatoDto);
        this._unitOfWork.Formatos.Add(formatos);
        await _unitOfWork.SaveAsync();

        if (formatos == null)
        {
            return BadRequest();
        }
        FormatoDto.Id = formatos.Id;
        return CreatedAtAction(nameof(Post), new { id = FormatoDto.Id }, FormatoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatoDto>> Put(int id, [FromBody] FormatoDto FormatoDto)
    {
        if (FormatoDto.Id == 0)
        {
            FormatoDto.Id = id;
        }

        if (FormatoDto.Id != id)
        {
            return BadRequest();
        }

        if (FormatoDto == null)
        {
            return NotFound();
        }

        var formato = _mapper.Map<Formato>(FormatoDto);
        _unitOfWork.Formatos.Update(formato);
        await _unitOfWork.SaveAsync();
        return FormatoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);

        if (formato == null)
        {
            return NotFound();
        }

        _unitOfWork.Formatos.Remove(formato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
