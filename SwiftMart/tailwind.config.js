/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./../**/*.{razor,html,cshtml}'],
  theme: {
    extend: {},
    },
    daisyui: {
        themes: ["light", "dark", "cupcake"],
    },
    plugins: [
        require('@tailwindcss/typography'),
        require('@tailwindcss/forms'),
        require("daisyui"),
    ],
    maxWidth: {
        '1/4': '25%',
        '1/2': '50%',
        '3/4': '75%',
    }

}

