export const blobToURL = (imgBg) => {
    const promise = new Promise(async resolve => {
      const byteCharacters = atob(imgBg)

      // Convert the byte string to a Uint8Array
      const byteNumbers = new Uint8Array(byteCharacters.length)
      for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i)
      }

      // Create a Blob object from the Uint8Array
      const byteArray = new Blob([byteNumbers], { type: 'image/jpeg' })

      // Create a data URL
      const imageUrl = URL.createObjectURL(byteArray)
      resolve(imageUrl)
    })

    return promise
  }