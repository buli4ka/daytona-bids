import puppeteer from 'puppeteer';


// todo check !json, adjust waiting logic 
export const launchParser = async () => {
    const browser = await puppeteer.launch({ channel: 'chrome', headless: false });
    const page = await browser.newPage();

    let json
    // await page.setRequestInterception(true);

    page.on('response', async (interceptedResponse) => {

        if (interceptedResponse.url().includes('VEHICLE_FINDER') || interceptedResponse.url().includes('profile/user')) {
            json = await interceptedResponse.json();
            console.log(json);

        }
        //     console.log("XHR Response", interceptedResponse.status(), interceptedResponse.url());
        //     console.log("Headers", interceptedResponse.headers());
        //     interceptedResponse.text().then((text) => console.log("Body", text));
        // }
    });
    await page.setViewport({width: 1080, height: 1024});

    // Navigate the page to a URL
    await page.goto('https://www.copart.com/vehicleFinder/');
    await page.waitForNetworkIdle();
    await browser.close();
    
    return json;
}