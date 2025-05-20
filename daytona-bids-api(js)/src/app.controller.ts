import { Controller, Get } from '@nestjs/common';
import { AppService } from './app.service';
import puppeteer from 'puppeteer';

async function run() {
  const browser = await puppeteer.launch();
  const page = await browser.newPage();
  await page.setViewport({ width: 1024, height: 768 });
  await page.setRequestInterception(true);
  await page.goto('');
}

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  getHello(): string {
    return this.appService.getHello();
  }
}
