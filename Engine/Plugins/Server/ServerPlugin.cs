﻿using Engine.Plugins.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Plugins.Server
{
  /// <summary>
  /// Представляет базовый класс для реализации плагина.
  /// </summary>
  public abstract class ServerPlugin :
    CrossDomainObject,
    IPlugin<ServerModelWrapper>
  {
    public abstract string Name { get; }
    public abstract string MenuCaption { get; }
    public abstract List<ServerPluginCommand> Commands { get; }

    public abstract void Initialize(ServerModelWrapper model);
    public abstract void InvokeMenuHandler();
  }
}