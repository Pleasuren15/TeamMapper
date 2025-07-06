export function getRandomPosition() {
    return {
        x: 100 + Math.random() * 900,
        y: 50 + Math.random() * 300
    };
};

export function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

const utils = {
  getRandomPosition,
  getRandomColor
};

export default utils;