using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Commands.User;

namespace Application.Mapper
{
    public static class UserMapper
    {
        public static Domain.Entities.User CommandToEntity(CreateUserCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CreateUserCommand, Domain.Entities.User>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.User>(command);
        }

        public static Domain.Entities.User CommandToEntity(UpdateUserCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<UpdateUserCommand, Domain.Entities.User>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.User>(command);
        }
    }

}
