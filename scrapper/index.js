import { createServer, version as viteVersion } from 'vite';
import { ViteNodeRunner } from 'vite-node/client';
import { ViteNodeServer } from 'vite-node/server';
import { installSourcemapsSupport } from 'vite-node/source-map';
import { config } from "dotenv";
import { resolve } from 'path';
const mode = process.env.NODE_ENV || 'development';
config({ path: resolve(process.cwd(), `.env.${mode}`) });
// create vite server
const server = await createServer({
    optimizeDeps: {
        // It's recommended to disable deps optimization
        noDiscovery: true,
    },
});
// For old Vite, this is need to initialize the plugins.
if (Number(viteVersion.split('.')[0]) < 6) {
    await server.pluginContainer.buildStart({});
}
// create vite-node server
const node = new ViteNodeServer(server);
// fixes stacktraces in Errors
installSourcemapsSupport({
    getSourceMap: source => node.getSourceMap(source),
});
// create vite-node runner
const runner = new ViteNodeRunner({
    root: server.config.root,
    base: server.config.base,
    // when having the server and runner in a different context,
    // you will need to handle the communication between them
    // and pass to this function
    fetchModule(id) {
        return node.fetchModule(id);
    },
    resolveId(id, importer) {
        return node.resolveId(id, importer);
    },
});
// execute the file
await runner.executeFile('./src/app.ts');
// close the vite server
await server.close();
