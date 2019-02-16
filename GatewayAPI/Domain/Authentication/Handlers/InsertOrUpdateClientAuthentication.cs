using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Infrastructure;
using Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Authentication.Handlers
{
    public class InsertOrUpdateClientAuthentication : BaseHandler, IInsertOrUpdateClientAuthentication
    {
        public InsertOrUpdateClientAuthentication(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }

        public async Task<int> ExecuteAsync(ClientAuthenticationDto dto)
        {
            if(dto == null)
                throw new ArgumentException();

            //Check if it exists
            var updateEntity = await Context.ClientAuthentications.FindAsync(dto.Id);

            if (updateEntity != null)
            {
                updateEntity.UserName = dto.UserName;
                updateEntity.Token = dto.Token;

                Context.ClientAuthentications.Update(updateEntity);
                await Context.SaveChangesAsync();
                return updateEntity.Id;
            }

            var insertEntity = mapper.Map<ClientAuthenticationDto, ClientAuthentication>(dto);
            insertEntity.DateCreated = DateTime.Now;
            Context.ClientAuthentications.Add(insertEntity);
            await Context.SaveChangesAsync();
            return insertEntity.Id;
        }
    }

    public interface IInsertOrUpdateClientAuthentication
    {
        Task<int> ExecuteAsync(ClientAuthenticationDto dto);
    }
}
