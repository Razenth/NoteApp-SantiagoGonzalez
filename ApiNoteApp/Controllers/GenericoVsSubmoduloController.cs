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
public class GenericoVsSubmoduloController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericoVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericoVsSubmoduloDto>>> Get()
    {
        var nombreVariable = await _unitOfWork.GenericosVsSubmodulos.GetAllAsync();
        return _mapper.Map<List<GenericoVsSubmoduloDto>>(nombreVariable);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubmoduloDto>> Get(int id)
    {
        var nombreVariable = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);

        if (nombreVariable == null)
        {
            return NotFound();
        }

        return _mapper.Map<GenericoVsSubmoduloDto>(nombreVariable);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericoVsSubmodulo>> Post(GenericoVsSubmoduloDto GenericoVsSubmoduloDto)
    {
        var nombreVariable = _mapper.Map<GenericoVsSubmodulo>(GenericoVsSubmoduloDto);
        this._unitOfWork.GenericosVsSubmodulos.Add(nombreVariable);
        await _unitOfWork.SaveAsync();

        if (nombreVariable == null)
        {
            return BadRequest();
        }
        GenericoVsSubmoduloDto.Id = nombreVariable.Id;
        return CreatedAtAction(nameof(Post), new { id = GenericoVsSubmoduloDto.Id }, GenericoVsSubmoduloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericoVsSubmoduloDto>> Put(int id, [FromBody] GenericoVsSubmoduloDto GenericoVsSubmoduloDto)
    {
        if (GenericoVsSubmoduloDto.Id == 0)
        {
            GenericoVsSubmoduloDto.Id = id;
        }

        if (GenericoVsSubmoduloDto.Id != id)
        {
            return BadRequest();
        }

        if (GenericoVsSubmoduloDto == null)
        {
            return NotFound();
        }

        var nombreVariable = _mapper.Map<GenericoVsSubmodulo>(GenericoVsSubmoduloDto);
        _unitOfWork.GenericosVsSubmodulos.Update(nombreVariable);
        await _unitOfWork.SaveAsync();
        return GenericoVsSubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var nombreVariable = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);

        if (nombreVariable == null)
        {
            return NotFound();
        }

        _unitOfWork.GenericosVsSubmodulos.Remove(nombreVariable);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
