global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Globalization;
global using System.Net;
global using System.Net.Http.Json;
global using System.Text.Json;
global using System.Text.Json.Serialization;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;

global using MediatR;

global using Author.Application.Common.Abstractions;
global using Author.Application.Common.Dtos;
global using Author.Application.Common.Exceptions;
global using Author.Application.Common.Models;
global using Author.Application.Common.Security;

global using Author.Domain.Abstractions;
global using Author.Domain.Constants;
global using Author.Domain.Entities;
global using Author.Domain.Events;