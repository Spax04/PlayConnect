export const calculateGameResult = (
  currentLvl,
  currentPoints,
  isWon,
  isTie,
  steps,
  seconds,
  maxPointPreGame
) => {
  const totalPointsToNextLvl = currentLvl * 100;

  let newLvl = currentLvl;
  let newPoints = currentPoints;
  let bonus = 0;

  console.log("Steps: " + steps);
  console.log("Seconds: " + seconds);
  console.log("Current Points: " + currentPoints);

  if (isTie) {
    newPoints += 12.5;
  } else {
    if (isWon) {
      // Adjusting bonus calculation based on steps and seconds
      bonus = maxPointPreGame - steps * (seconds / 100);

      console.log("Bonus: " + bonus);
      newPoints += 15 + bonus;
    } else {
      newPoints += 10;
    }
  }

  const pointsLeftToNextLvl = totalPointsToNextLvl - newPoints;
  if (pointsLeftToNextLvl <= 0) {
    newLvl++;
    newPoints = Math.abs(pointsLeftToNextLvl);
  }

  const pointsToNextLvl = newLvl * 100 - newPoints;
  return { newLvl, newPoints, pointsToNextLvl };
};
