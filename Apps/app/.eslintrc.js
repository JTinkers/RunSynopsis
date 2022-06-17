module.exports = {
  root: true,
  env: {
    node: true
  },
  'extends': [
    'plugin:vue/vue3-essential',
    'eslint:recommended',
    '@vue/typescript/recommended'
  ],
  parserOptions: {
    ecmaVersion: 2020
  },
  rules: {
        'brace-style': ['warn', 'allman', { allowSingleLine: true }],
        'quotes': ['warn', 'single'],
        'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
        'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
        'vue/html-quotes': ['warn', 'single'],
        'vue/html-closing-bracket-newline': 
        [
            'warn', 
            {
                'singleline': 'never',
                'multiline': 'always',
            }
        ],
        'vue/multi-word-component-names': 'off',
        'vue/html-end-tags': 'warn',
        'vue/html-self-closing': 
        [
            'warn',
            {
                'html':
                {
                    'void': 'never',
                    'normal': 'always',
                    'component': 'always',
                },
                'svg': 'always',
                'math': 'always'
            }
        ],
        'vue/max-attributes-per-line':
        [
            'warn',
            {
                'singleline': 
                {
                    'max': 2
                },
                'multiline': 
                {
                    'max': 1
                }
            }
        ],
        'vue/no-multi-spaces': 'warn',
        'vue/prop-name-casing': ['warn', 'camelCase'],
        'vue/require-explicit-emits': ['warn'],
        'vue/v-on-event-hyphenation': ['warn'],
        'vue/no-unused-vars': ['warn'],
        '@typescript-eslint/no-explicit-any': 'off',
        '@typescript-eslint/no-unused-vars': 'off',
        '@typescript-eslint/no-non-null-assertion': 'off',
        '@typescript-eslint/no-empty-function': 'warn',
        'no-undef': 'off'
    }
}
