import asyncio
import os
from playwright.async_api import async_playwright

async def run():
    artifact_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
    docs_img_dir = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images"
    os.makedirs(artifact_dir, exist_ok=True)
    os.makedirs(docs_img_dir, exist_ok=True)

    async with async_playwright() as p:
        browser = await p.chromium.launch(headless=True)

        # 1. Desktop Test (1440x900)
        page = await browser.new_page(viewport={"width": 1440, "height": 900})
        print("[Desktop] Navigating to http://127.0.0.1:5128...")
        await page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        await asyncio.sleep(2)

        # Check APM Activity Meter in Header
        print("[Desktop] Checking TwActivityMeter in header...")
        apm_meter = page.locator("button:has-text('APM')").first
        assert await apm_meter.is_visible(), "APM activity meter should be visible in header"
        text = await apm_meter.text_content()
        print(f"[Desktop] APM Meter text: {text.strip()}")

        # Click APM Meter to open Telemetry Cockpit
        await apm_meter.click()
        await asyncio.sleep(1)

        # Verify Telemetry Cockpit is displayed
        print("[Desktop] Verifying OpenTelemetry APM Cockpit...")
        cockpit_header = page.locator("h4:has-text('OpenTelemetry APM Cockpit')")
        assert await cockpit_header.is_visible(), "Cockpit header must be visible"

        badge_w3c = page.locator("text='LIVE W3C TRACE'")
        assert await badge_w3c.is_visible(), "W3C Trace badge should be visible"

        # Check KPI cards
        print("[Desktop] Verifying KPI metric cards...")
        assert await page.locator("text='Total Spans'").first.is_visible()
        assert await page.locator("text='Avg Render Latency'").first.is_visible()
        assert await page.locator("text='Frame Rate'").first.is_visible()
        assert await page.locator("text='WASM Heap Allocation'").first.is_visible()

        # Click 'Record Activity Burst'
        print("[Desktop] Clicking Record Activity Burst...")
        burst_btn = page.locator("button:has-text('Record Activity Burst')")
        await burst_btn.click()
        await asyncio.sleep(0.5)
        await burst_btn.click()
        await asyncio.sleep(0.8)

        # Verify Waterfall spans are present
        print("[Desktop] Verifying Waterfall & Flame Graph...")
        spans = page.locator(".btui-telemetry-dashboard .cursor-pointer")
        count = await spans.count()
        assert count > 0, "Waterfall spans should be rendered"
        print(f"[Desktop] Found {count} activity spans in waterfall")

        # Click first span to inspect W3C traceparent
        await spans.first.click()
        await asyncio.sleep(0.4)
        traceparent = page.locator("text='W3C Traceparent:'")
        assert await traceparent.is_visible(), "W3C Traceparent details should be expanded"

        # Switch to Component Leaderboard Tab
        print("[Desktop] Checking Component Leaderboard tab...")
        leaderboard_tab = page.locator("button:has-text('Component Leaderboard')")
        await leaderboard_tab.click()
        await asyncio.sleep(0.6)
        table_header = page.locator("th:has-text('Component')")
        assert await table_header.is_visible(), "Leaderboard table should be visible"
        rows = page.locator("tbody tr")
        row_count = await rows.count()
        print(f"[Desktop] Leaderboard rows: {row_count}")
        assert row_count > 0, "Leaderboard should have component rows"

        # Switch to WASM & GC Vitals Tab
        print("[Desktop] Checking WASM & GC Vitals tab...")
        vitals_tab = page.locator("button:has-text('WASM & GC Vitals')")
        await vitals_tab.click()
        await asyncio.sleep(0.6)
        assert await page.locator("text='GC Collections'").is_visible(), "GC Collections card should be visible"
        assert await page.locator("text='Total Managed Heap:'").is_visible(), "Memory Allocation card should be visible"

        # Switch to W3C OTLP JSON Export Tab
        print("[Desktop] Checking W3C OTLP JSON Export tab...")
        otlp_tab = page.locator("button:has-text('W3C OTLP JSON Export')")
        await otlp_tab.click()
        await asyncio.sleep(0.6)
        json_pre = page.locator("pre:has-text('resourceSpans')")
        assert await json_pre.is_visible(), "OTLP JSON payload should be rendered"
        json_content = await json_pre.text_content()
        assert "BlazorTailwindUI" in json_content, "Service name should be in OTLP JSON"

        # Switch back to Waterfall for screenshot
        waterfall_tab = page.locator("button:has-text('Waterfall & Flame Graph')")
        await waterfall_tab.click()
        await asyncio.sleep(0.6)

        desktop_art = os.path.join(artifact_dir, "suite-telemetry-apm.png")
        desktop_docs = os.path.join(docs_img_dir, "suite-telemetry-apm.png")
        await page.screenshot(path=desktop_art, full_page=False)
        await page.screenshot(path=desktop_docs, full_page=False)
        print(f"[Desktop] Saved screenshots to {desktop_art} and {desktop_docs}")

        await page.close()

        # 2. Mobile Test (375x812 - iPhone 13)
        print("\n[Mobile] Running Mobile 375x812 test...")
        m_page = await browser.new_page(viewport={"width": 375, "height": 812}, is_mobile=True)

        await m_page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        await asyncio.sleep(2)

        # Click APM meter in header
        m_apm = m_page.locator("button:has-text('APM')").first
        assert await m_apm.is_visible(), "Mobile APM meter should be visible in header"
        await m_apm.click()
        await asyncio.sleep(1)

        # Verify Cockpit rendered responsively
        assert await m_page.locator("h4:has-text('OpenTelemetry APM Cockpit')").is_visible()
        burst_btn_mobile = m_page.locator("button:has-text('Record Activity Burst')")
        await burst_btn_mobile.click()
        await asyncio.sleep(0.6)

        mobile_art = os.path.join(artifact_dir, "suite-telemetry-apm-mobile.png")
        await m_page.screenshot(path=mobile_art, full_page=False)
        print(f"[Mobile] Saved mobile screenshot to {mobile_art}")

        await m_page.close()
        await browser.close()

    print("\nALL TELEMETRY APM E2E TESTS PASSED 100%!")

if __name__ == "__main__":
    asyncio.run(run())
