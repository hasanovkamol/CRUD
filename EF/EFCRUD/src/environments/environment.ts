// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  api_schema: 'http://',
  api_url: 'localhost:53912/',
  API_BASE_URL: 'http://localhost:23624',

  baseUrl() {
      return this.api_schema + this.api_url;
  },
};
