SELECT * FROM Movie 
JOIN MovieToDirector ON Movie.Id = MovieToDirector.MovieId 
JOIN Director ON Director.Id = MovieToDirector.DirectorId
WHERE MovieToDirector.DirectorId = 1