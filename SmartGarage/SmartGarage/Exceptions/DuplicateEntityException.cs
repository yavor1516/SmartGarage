﻿using System;

namespace ForumSystem.Exceptions
{
	public class DuplicateEntityException : ApplicationException
	{
		public DuplicateEntityException(string message)
			: base(message)
		{
		}
	}
}
