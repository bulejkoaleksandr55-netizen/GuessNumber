using GuessNumber.Application;
using GuessNumber.Domain;

var generator = new RandomNumberGenerator();
var gameManager = new GameManager(generator);

gameManager.Start();