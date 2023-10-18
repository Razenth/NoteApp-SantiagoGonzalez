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
public class MaestroVsSubmoduloController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaestroVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MaestroVsSubmoduloDto>>> Get()
    {
        var maestrosModulos = await _unitOfWork.MaestrosVsSubmodulos.GetAllAsync();
        return _mapper.Map<List<MaestroVsSubmoduloDto>>(maestrosModulos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmoduloDto>> Get(int id)
    {
        var maestroModulo = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(id);

        if (maestroModulo == null)
        {
            return NotFound();
        }

        return _mapper.Map<MaestroVsSubmoduloDto>(maestroModulo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestroVsSubmodulo>> Post(MaestroVsSubmoduloDto MaestroVsSubmoduloDto)
    {
        var maestrosModulos = _mapper.Map<MaestroVsSubmodulo>(MaestroVsSubmoduloDto);
        this._unitOfWork.MaestrosVsSubmodulos.Add(maestrosModulos);
        await _unitOfWork.SaveAsync();

        if (maestrosModulos == null)
        {
            return BadRequest();
        }
        MaestroVsSubmoduloDto.Id = maestrosModulos.Id;
        return CreatedAtAction(nameof(Post), new { id = MaestroVsSubmoduloDto.Id }, MaestroVsSubmoduloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmoduloDto>> Put(int id, [FromBody] MaestroVsSubmoduloDto MaestroVsSubmoduloDto)
    {
        if (MaestroVsSubmoduloDto.Id == 0)
        {
            MaestroVsSubmoduloDto.Id = id;
        }

        if (MaestroVsSubmoduloDto.Id != id)
        {
            return BadRequest();
        }

        if (MaestroVsSubmoduloDto == null)
        {
            return NotFound();
        }

        if (MaestroVsSubmoduloDto.FechaModificacion == DateTime.MinValue)
        {
            MaestroVsSubmoduloDto.FechaModificacion = DateTime.Now;
        }

        var maestroModulo = _mapper.Map<MaestroVsSubmodulo>(MaestroVsSubmoduloDto);
        _unitOfWork.MaestrosVsSubmodulos.Update(maestroModulo);
        await _unitOfWork.SaveAsync();
        return MaestroVsSubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var maestroModulo = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(id);

        if (maestroModulo == null)
        {
            return NotFound();
        }

        _unitOfWork.MaestrosVsSubmodulos.Remove(maestroModulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
