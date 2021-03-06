//
// LuaOpaqueClrObject.cs
//
// Authors:
//       Chris Howie <me@chrishowie.com>
//       Tom Roostan <RoosterDragon@outlook.com>
//
// Copyright (c) 2013 Chris Howie
// Copyright (c) 2015 Tom Roostan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Eluant.ObjectBinding;

namespace Eluant
{
    public sealed class LuaOpaqueClrObject : LuaClrObjectValue, IEquatable<LuaOpaqueClrObject>
    {
        public LuaOpaqueClrObject(object obj) : base(obj) { }

        internal override void Push(LuaRuntime runtime)
        {
            runtime.PushOpaqueClrObject(this);
        }

        public override bool Equals(LuaValue other)
        {
            return Equals(other as LuaOpaqueClrObject);
        }

        public bool Equals(LuaOpaqueClrObject obj)
        {
            return obj != null && obj.ClrObject == ClrObject;
        }

        internal override object BackingCustomObject
        {
            get { return null; }
        }

        internal override MetamethodAttribute[] BackingCustomObjectMetamethods(LuaRuntime runtime)
        {
            return null;
        }
    }
}

