﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieSeries.Controllers;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSeriesTest.Controller
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _serviceMock;
        private readonly MovieController _controller;
        public MovieControllerTests()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new MovieController(_serviceMock.Object);
        }
        [Fact]
        public async Task GetMovies_ReturnsOkResult_WithListOfMovies()
        {
            // Arrange
            var movies = new List<Movie> { new Movie { Title = "Inception" }, new Movie { Title = "The Matrix" } };
            _serviceMock.Setup(s =>
            s.GetAllMoviesAsync()).ReturnsAsync(movies);
            // Act
            var result = await _controller.GetAllMovies();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(movies, okResult.Value);
        }
        [Fact]
        public async Task
        AddMovie_ReturnsCreatedAtActionResult_WhenMovieIsValid()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Inception",
                Genre = "Sci-Fi"
            };
            _serviceMock.Setup(s =>
            s.AddMovieAsync(movie)).Returns(Task.CompletedTask);
            // Act
            var result = await _controller.AddMovie(movie);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }


}
