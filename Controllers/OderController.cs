﻿using BE_Shop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BE_Shop.Controllers
{
	/// <summary>
	/// Thông in địa chỉ
	/// </summary>
	[ApiController]
	[Route("/api/order")]
	[Produces("application/json")]
	public class OrderController : BaseController
	{
		/// <summary>
		/// Thêm hóa đơn
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddOrder input)
		{

			return await QueryCheck<OutputAddOrder>((input, Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value)));
		}
		/// <summary>
		/// Sửa hóa đơn
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateOrder input)
		{
			return await QueryCheck<OutputUpdateOrder>(input);
		}
		/// <summary>
		/// Xóa hóa đơn
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize]
		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			return await QueryCheck<OutputDeleteOrder>(Id);
		}
		/// <summary>
		/// Lấy danh sách hóa đơn
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize(Roles = "Admin")]
		[HttpPost("list")]
		public async Task<IActionResult> GetAll([FromBody] GetAllOrder input)
		{
			return await QueryCheck<OutputGetAllOrder>(input);
		}
		/// <summary>
		/// Lấy danh sách hóa đơn của tôi
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize]
		[HttpPost("listmine")]
		public async Task<IActionResult> GetAllMine([FromBody] GetAllOrder input)
		{
			return await QueryCheck<OutputGetAllOrderMine>((input, Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value)));
		}
		/// <summary>
		/// Lấy thông tin hóa đơn
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[Authorize]
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetOne(Guid Id)
		{
			return await QueryCheck<OutputGetOneOrder>(Id);
		}
	}
}
