using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EternalFrost.Utils.Collections
{
	class IdentityEqualityComparer<T> : IEqualityComparer<T>
	{
		bool IEqualityComparer<T>.Equals(T x, T y)
		{
			return object.ReferenceEquals(x, y);
		}

		int IEqualityComparer<T>.GetHashCode(T obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}


}

