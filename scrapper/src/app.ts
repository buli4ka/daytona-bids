import fastify from 'fastify'
import {launchParser} from "./parser/index.js";
const server = fastify();



const PORT = process.env.API_PORT  as unknown as number || 5000;
server.get('/ping', async (request, reply) => {
    return 'pong\n'
})

server.post('/generate', async (request, reply) => {
    return await launchParser();
})

server.get('/test', async (request, reply) => {
    
})

server.listen({ port: PORT }, (err, address) => {
    if (err) {
        console.error(err)
        process.exit(1)
    }
    console.log(`Server listening at ${address}`)
})
