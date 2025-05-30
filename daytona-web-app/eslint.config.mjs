import { dirname } from "path";
import { fileURLToPath } from "url";
import { FlatCompat } from "@eslint/eslintrc";

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);

const compat = new FlatCompat({
  baseDirectory: __dirname,
});

const eslintConfig = [
  ...compat.config({
    extends: [
      "next/core-web-vitals",
      "next/typescript",
      'plugin:prettier/recommended',
    ],
    plugins: [
      '@typescript-eslint/eslint-plugin',
      'prettier',
      'react',
    ],

    rules: {
      'prettier/prettier': ["error", { "endOfLine": "auto",
        semi: true,
        trailingComma: 'all',
        singleQuote: true,
        jsxSingleQuote: true,
        printWidth: 120,
        tabWidth: 2,
        arrowParens: 'avoid'
      }],
      'react/jsx-no-bind': [
        'warn',
        {
          ignoreDOMComponents: false,
          ignoreRefs: false,
          allowArrowFunctions: true,
          allowFunctions: false,
          allowBind: false,
        },
      ],
      'react/prop-types': 'off',
      'react/display-name': 'off',
      'react/self-closing-comp': [
        'warn',
        {
          component: true,
          html: true,
        },
      ],
      'react/jsx-boolean-value': ['error'],
      '@typescript-eslint/no-unused-vars': 'warn',
      '@typescript-eslint/no-this-alias': 'error',
      '@typescript-eslint/no-empty-function': 'off',
      '@typescript-eslint/no-explicit-any': 'warn',
      '@typescript-eslint/no-non-null-assertion': 'off',
      '@typescript-eslint/explicit-function-return-type': 'off',
      '@typescript-eslint/explicit-module-boundary-types': 'off',
      '@typescript-eslint/ban-ts-comment': 'warn',
      '@typescript-eslint/no-empty-interface': 'error',
      '@typescript-eslint/no-misused-new': ['error'],
      '@typescript-eslint/no-shadow': 'error',
      '@typescript-eslint/no-extraneous-class': 'error',
      '@typescript-eslint/unified-signatures': 'error',
      '@typescript-eslint/consistent-type-assertions': 'error',
      '@typescript-eslint/no-base-to-string': 'error',
      '@typescript-eslint/no-confusing-non-null-assertion': 'error',
      '@typescript-eslint/no-dynamic-delete': 'error',
      '@typescript-eslint/no-require-imports': 'error',
      '@typescript-eslint/no-unnecessary-boolean-literal-compare': 'error',
      '@typescript-eslint/no-unnecessary-qualifier': 'error',
      '@typescript-eslint/no-implied-eval': 'error',
      '@typescript-eslint/no-for-in-array': 'error',
      '@typescript-eslint/no-implicit-any-catch': 'off',
      '@typescript-eslint/no-non-null-asserted-optional-chain': 'error',
      '@typescript-eslint/no-unnecessary-type-arguments': 'error',
      '@typescript-eslint/no-unnecessary-type-assertion': 'error',
      '@typescript-eslint/prefer-enum-initializers': 'error',
      '@typescript-eslint/prefer-for-of': 'error',
      '@typescript-eslint/prefer-includes': 'error',
      '@typescript-eslint/prefer-reduce-type-parameter': 'error',
      '@typescript-eslint/promise-function-async': 'error',
      '@typescript-eslint/require-array-sort-compare': 'error',
      '@typescript-eslint/restrict-plus-operands': 'error',
      '@typescript-eslint/switch-exhaustiveness-check': 'error',
      '@typescript-eslint/no-magic-numbers': [
        'warn',
        {
          enforceConst: true,
          ignoreEnums: true,
          ignoreReadonlyClassProperties: true,
          ignore: [-1, 0, 1, 2],
        },
      ],
      '@typescript-eslint/array-type': [
        'error',
        {
          default: 'array',
          readonly: 'array',
        },
      ],
      '@typescript-eslint/no-inferrable-types': [
        'error',
        {
          ignoreProperties: true,
          ignoreParameters: true,
        },
      ],
      'curly': 'error',
      'guard-for-in': 'error',
      'no-labels': 'error',
      'no-bitwise': 'error',
      'no-loop-func': 'error',
      'no-constructor-return': 'error',
      'no-empty': 'error',
      'no-eval': 'error',
      'no-throw-literal': 'warn',
      'no-var': 'error',
      'no-extra-bind': 'error',
    },
    parserOptions: {
      project: 'tsconfig.json',
      tsconfigRootDir: __dirname,
      sourceType: 'module',
    },
  }),
];

export default eslintConfig;
