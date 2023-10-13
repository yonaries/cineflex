    public class CinemaCommandHandler
    {
        private readonly CinemaRepository _cinemaRepository;
        private readonly IValidator<Cinema> createCinemaValidator;
        private readonly IValidator<Cinema> updateCinemaValidator;

        public CinemaCommandHandler(CinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task Handle(CreateCinemaCommand command)
        {
            var validationResult = createCinemaValidator.Validate(command.Cinema);

            if (validationResult.IsValid)
            {
                await _cinemaRepository.CreateCinemaAsync(command.Cinema);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task Handle(UpdateCinemaCommand command)
        {
            var validationResult = updateCinemaValidator.Validate(command.Cinema);

            if (validationResult.IsValid)
            {
                await _cinemaRepository.UpdateCinemaAsync(command.Cinema);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task Handle(DeleteCinemaCommand command)
        {
            await _cinemaRepository.DeleteCinemaAsync(command.Id);
        }
    }
