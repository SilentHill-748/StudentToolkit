global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.ComponentModel;
global using System.Windows.Input;

global using CommunityToolkit.Mvvm.Messaging;
global using CommunityToolkit.Mvvm.Messaging.Messages;

global using FluentValidation;

global using Mapster;

global using Serilog;

global using StudentToolkit.Application.Common.Interfaces.Services;
global using StudentToolkit.Application.DI;
global using StudentToolkit.Configuration.DI;
global using StudentToolkit.Infrastructure.DI;
global using StudentToolkit.MVVM.Models.Navigation;
global using StudentToolkit.MVVM.Models.Navigation.Messages;
global using StudentToolkit.MVVM.Models.Navigation.Messages.Queries;
global using StudentToolkit.MVVM.Stores;
global using StudentToolkit.MVVM.ViewModels;
global using StudentToolkit.MVVM.ViewModels.Base;
global using StudentToolkit.MVVM.ViewModels.Components;
global using StudentToolkit.MVVM.ViewModels.Model;
global using StudentToolkit.MVVM.ViewModels.Presentation.CreateGroup;
global using StudentToolkit.MVVM.Views.Windows;
global using StudentToolkit.WpfCore.Commands.CreateGroup;
global using StudentToolkit.WpfCore.Common.Enums;
global using StudentToolkit.WpfCore.Exceptions.Navigation;
global using StudentToolkit.WpfCore.Services;

global using Container = SimpleInjector.Container;
