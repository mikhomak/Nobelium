﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComponent
{
    void activate();

    void deactivate();

    void addToListeners();

}
