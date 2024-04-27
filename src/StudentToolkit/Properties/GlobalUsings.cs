global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Collections.Specialized;
global using System.ComponentModel;
global using System.Windows.Input;

global using CommunityToolkit.Mvvm.Messaging;
global using CommunityToolkit.Mvvm.Messaging.Messages;

global using FluentValidation;

global using Mapster;

global using Serilog;

global using StudentToolkit.Application.Common.Constants;
global using StudentToolkit.Application.Common.Exceptions;
global using StudentToolkit.Application.Common.Interfaces.Services;
global using StudentToolkit.Application.DI;
global using StudentToolkit.Application.Extensions;
global using StudentToolkit.Configuration.DI;
global using StudentToolkit.Infrastructure.DI;
global using StudentToolkit.Navigation;
global using StudentToolkit.Navigation.Messages;
global using StudentToolkit.Stores.Group;
global using StudentToolkit.MVVM.ViewModels;
global using StudentToolkit.MVVM.ViewModels.Base;
global using StudentToolkit.MVVM.ViewModels.Components;
global using StudentToolkit.MVVM.ViewModels.Model;
global using StudentToolkit.MVVM.Group.CreateGroup.ViewModels;
global using StudentToolkit.MVVM.Group.GroupInfo.ViewModels;
global using StudentToolkit.MVVM.Views.Windows;
global using StudentToolkit.WpfCore.Commands.Base;
global using StudentToolkit.WpfCore.Commands.Navigation;
global using StudentToolkit.WpfCore.Commands.Presentation.Group;
global using StudentToolkit.WpfCore.Commands.Presentation.Main;
global using StudentToolkit.WpfCore.Common.Enums;
global using StudentToolkit.WpfCore.Exceptions;
global using StudentToolkit.WpfCore.Services;

global using Container = SimpleInjector.Container;
