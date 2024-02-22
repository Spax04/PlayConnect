export const calculateGameResult = (
  currentLvl,
  currentPoints,
  isWon,
  isTie
) => {
  const totalPoiontsToNextLvl = currentLvl * 100

  let newLvl = currentLvl
  let newPoints = currentPoints
  if (isTie) {
    newPoints = currentPoints + 15
  } else {
    if (isWon) {
      newPoints = currentPoints + 20
    } else {
      newPoints = currentPoints + 10
    }
  }
  const pointsLeftToNextLvl = totalPoiontsToNextLvl - newPoints
  if (pointsLeftToNextLvl <= 0) {
    newLvl++
    newPoints = Math.abs(pointsLeftToNextLvl)
  }

  const pointsToNextLvl = newLvl * 100 - newPoints
  return { newLvl, newPoints, pointsToNextLvl }
}
