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

namespace ApiNoteApp.Controllers
{
    public class SubmoduloController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubmoduloDto>>> Get()
        {
            var submodulos = await _unitOfWork.Submodulos.GetAllAsync();
            return _mapper.Map<List<SubmoduloDto>>(submodulos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubmoduloDto>> Get(int id)
        {
            var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);

            if (submodulo == null)
            {
                return NotFound();
            }

            return _mapper.Map<SubmoduloDto>(submodulo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Submodulo>> Post(SubmoduloDto SubmoduloDto)
        {
            var submodulos = _mapper.Map<Submodulo>(SubmoduloDto);
            this._unitOfWork.Submodulos.Add(submodulos);
            await _unitOfWork.SaveAsync();

            if (submodulos == null)
            {
                return BadRequest();
            }
            SubmoduloDto.Id = submodulos.Id;
            return CreatedAtAction(nameof(Post), new { id = SubmoduloDto.Id }, SubmoduloDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubmoduloDto>> Put(int id, [FromBody] SubmoduloDto SubmoduloDto)
        {
            if (SubmoduloDto.Id == 0)
            {
                SubmoduloDto.Id = id;
            }

            if(SubmoduloDto.Id != id)
            {
                return BadRequest();
            }

            if(SubmoduloDto == null)
            {
                return NotFound();
            }

            if (SubmoduloDto.FechaModificacion == DateTime.MinValue)
            {
                SubmoduloDto.FechaModificacion = DateTime.Now;
            }

            var submodulo = _mapper.Map<Submodulo>(SubmoduloDto);
            _unitOfWork.Submodulos.Update(submodulo);
            await _unitOfWork.SaveAsync();
            return SubmoduloDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);

            if (submodulo == null)
            {
                return NotFound();
            }

            _unitOfWork.Submodulos.Remove(submodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}