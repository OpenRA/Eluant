//
// LuaCustomClrObject.cs
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
    public class LuaCustomClrObject : LuaClrObjectValue, IEquatable<LuaCustomClrObject>
    {
        public LuaCustomClrObject(object obj) : base(obj) { }

        internal override void Push(LuaRuntime runtime)
        {
            runtime.PushCustomClrObject(this);
        }

        public override bool Equals(LuaValue other)
        {
            return Equals(other as LuaCustomClrObject);
        }

        public bool Equals(LuaCustomClrObject other)
        {
            return other != null && other.ClrObject == ClrObject;
        }

        internal override object BackingCustomObject
        {
            get { return ClrObject; }
        }

        private MetamethodAttribute[] metamethods;

        internal override MetamethodAttribute[] BackingCustomObjectMetamethods(LuaRuntime runtime)
        {
            return metamethods ?? (metamethods = runtime.CachedMetamethods(BackingCustomObject.GetType()));
        }
    }
}

