/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
  './App.{js,ts,tsx}', 
  './src/**/*.{js,ts,tsx}' // <--- To przeskanuje CAŁY folder src (components, screens, navigation)
],

  presets: [require('nativewind/preset')],
  theme: {
    extend: {},
  },
  plugins: [],
};
