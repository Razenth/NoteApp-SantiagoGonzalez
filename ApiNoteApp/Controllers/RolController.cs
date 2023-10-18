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
    public class RolController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolDto>>> Get()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDto>>(roles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Get(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return _mapper.Map<RolDto>(rol);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> Post(RolDto RolDto)
        {
            var roles = _mapper.Map<Rol>(RolDto);
            this._unitOfWork.Roles.Add(roles);
            await _unitOfWork.SaveAsync();

            if (roles == null)
            {
                return BadRequest();
            }
            RolDto.Id = roles.Id;
            return CreatedAtAction(nameof(Post), new { id = RolDto.Id }, RolDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto RolDto)
        {
            if (RolDto.Id == 0)
            {
                RolDto.Id = id;
            }

            if(RolDto.Id != id)
            {
                return BadRequest();
            }

            if(RolDto == null)
            {
                return NotFound();
            }

            if (RolDto.FechaModificacion == DateTime.MinValue)
            {
                RolDto.FechaModificacion = DateTime.Now;
            }

            var rol = _mapper.Map<Rol>(RolDto);
            _unitOfWork.Roles.Update(rol);
            await _unitOfWork.SaveAsync();
            return RolDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var rol = await _unitOfWork.Roles.GetByIdAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            _unitOfWork.Roles.Remove(rol);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}