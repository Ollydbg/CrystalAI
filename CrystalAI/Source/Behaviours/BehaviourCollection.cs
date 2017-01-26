﻿// GPL v3 License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// BehaviourCollection.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Crystal AI.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;


namespace Crystal {

  public class BehaviourCollection : IBehaviourCollection {
    Dictionary<string, IBehaviour> _behavioursMap;
    public IOptionCollection Options { get; private set; }

    public bool Add(IBehaviour behaviour) {
      if(behaviour == null)
        return false;
      if(_behavioursMap.ContainsKey(behaviour.NameId))
        return false;
      if(string.IsNullOrEmpty(behaviour.NameId))
        return false;

      _behavioursMap.Add(behaviour.NameId, behaviour);
      return true;
    }

    public bool Contains(string behaviourId) {
      return _behavioursMap.ContainsKey(behaviourId);
    }

    public void Clear() {
      _behavioursMap.Clear();
    }

    public void ClearAll() {
      _behavioursMap.Clear();
      Options.ClearAll();
    }

    public IBehaviour Create(string behaviourId) {
      return _behavioursMap.ContainsKey(behaviourId) ? _behavioursMap[behaviourId].Clone() as IBehaviour : null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BehaviourCollection"/> class.
    /// </summary>
    /// <param name="optionCollection">The option collection.</param>
    /// <exception cref="Crystal.BehaviourCollection.OptionCollectionNullException"></exception>
    public BehaviourCollection(IOptionCollection optionCollection) {
      if(optionCollection == null)
        throw new OptionCollectionNullException();

      _behavioursMap = new Dictionary<string, IBehaviour>();
      Options = optionCollection;
    }

    internal class OptionCollectionNullException : Exception {
    }
  }

}