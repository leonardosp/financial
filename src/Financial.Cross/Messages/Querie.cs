using MediatR;

namespace Financial.Cross.Messages;

public abstract class Querie<T> : IRequest<T> where T : class { }
