import asyncio
import os
from playwright.async_api import async_playwright

async def run():
    async with async_playwright() as p:
        browser = await p.chromium.launch(headless=True)
        
        # 1. Desktop Test (1440x900)
        page = await browser.new_page(viewport={"width": 1440, "height": 900})
        print("Navigating to Blazor Tailwind UI at http://127.0.0.1:5128 ...")
        await page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        await asyncio.sleep(2)

        # Verify Sidebar Categories exist
        aside = page.locator("aside").first
        flagship_header = aside.get_by_text("Flagship Studios").first
        arch_header = aside.get_by_text("Architecture & AI").first
        enterprise_header = aside.get_by_text("Enterprise & Business").first
        ui_header = aside.get_by_text("UI Kit Catalog").first
        resources_header = aside.get_by_text("Resources & Docs").first

        assert await flagship_header.is_visible(), "Flagship Studios header should be visible"
        assert await arch_header.is_visible(), "Architecture & AI header should be visible"
        assert await enterprise_header.is_visible(), "Enterprise & Business header should be visible"
        assert await ui_header.is_visible(), "UI Kit Catalog header should be visible"
        assert await resources_header.is_visible(), "Resources & Docs header should be visible"
        print("PASS: All 5 Categorized Hubs visible in Sidebar!")

        # Verify In-Page Quick Jump Bar is visible
        jump_bar = page.locator("[data-testid='jump-bar']").first
        assert await jump_bar.is_visible(), "Quick Studio Jump Bar should be visible"
        print("PASS: Quick Studio Jump Bar visible!")

        # Test Sidebar Real-Time Navigation Filter
        filter_input = aside.locator("input[placeholder='Filter navigation...']").first
        await filter_input.fill("crm")
        await asyncio.sleep(0.5)

        # After filtering "crm", CRM Dashboard should be visible in sidebar, while Core Components should be filtered out
        crm_nav = aside.locator("button:has-text('CRM Dashboard')").first
        components_nav = aside.locator("button:has-text('Core Components')")
        assert await crm_nav.is_visible(), "CRM Dashboard should match 'crm' filter"
        assert not await components_nav.is_visible(), "Core Components should be filtered out of sidebar"
        print("PASS: Sidebar real-time filter correctly narrowed items down!")

        # Click CRM Dashboard from sidebar
        await crm_nav.click()
        await asyncio.sleep(1)

        # Check that dedicated CRM studio rendered
        dedicated_crm_title = page.get_by_text("CRM Draggable & Resizable Dashboard Studio").first
        assert await dedicated_crm_title.is_visible(), "Dedicated CRM studio view should be rendered"
        print("PASS: Dedicated CRM Dashboard studio view rendered successfully!")

        # Clear the search filter using the (X) clear button
        clear_btn = aside.locator("button[title='Clear filter']").first
        if await clear_btn.is_visible():
            await clear_btn.click()
        else:
            await filter_input.fill("")
        await asyncio.sleep(0.5)

        # Verify all groups restored in sidebar
        assert await components_nav.first.is_visible(), "Core Components should be restored after clearing filter"
        print("PASS: Clearing filter restored all navigation categories!")

        # Test Jump Bar: Click [✍️ PDF Form Maker] from jump bar
        pdf_jump_btn = jump_bar.locator("button:has-text('PDF Form Maker')").first
        await pdf_jump_btn.click()
        await asyncio.sleep(1)

        # Should switch to showcase and scroll to studio-pdf anchor
        pdf_card = page.locator("#studio-pdf")
        assert await pdf_card.is_visible(), "#studio-pdf anchor should be visible in showcase"
        print("PASS: Jump bar navigated to PDF Form Maker anchor!")

        # Test Jump Bar: Click [🛡️ C# 15 Union]
        union_jump_btn = jump_bar.locator("button:has-text('C# 15 Union')").first
        await union_jump_btn.click()
        await asyncio.sleep(1)
        union_card = page.locator("#studio-union")
        assert await union_card.is_visible(), "#studio-union anchor should be visible in showcase"
        print("PASS: Jump bar navigated to C# 15 Union Boundary anchor!")

        # Scroll to top to capture beautiful overview screenshot
        await page.evaluate("window.scrollTo(0, 0)")
        await asyncio.sleep(0.5)

        os.makedirs(r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images", exist_ok=True)
        desktop_screenshot = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images\suite-grouped-navigation.png"
        await page.screenshot(path=desktop_screenshot, full_page=False)
        print(f"PASS: Saved desktop screenshot to {desktop_screenshot}")

        # 2. Mobile Test (375x812)
        mobile_page = await browser.new_page(viewport={"width": 375, "height": 812})
        await mobile_page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        await asyncio.sleep(2)

        # Open mobile drawer menu
        hamburger = mobile_page.locator("button[aria-label='Toggle Navigation Drawer']")
        assert await hamburger.is_visible(), "Hamburger button should be visible on mobile"
        await hamburger.click()
        await asyncio.sleep(0.5)

        # Check mobile drawer categories and filter
        m_aside = mobile_page.locator("aside").first
        m_filter = m_aside.locator("input[placeholder='Filter navigation...']").first
        assert await m_filter.is_visible(), "Mobile drawer should contain real-time filter input"
        
        m_flagship = m_aside.get_by_text("Flagship Studios").first
        assert await m_flagship.is_visible(), "Mobile drawer should contain Flagship Studios group"
        print("PASS: Mobile drawer opened with categorized hubs and filter search!")

        # Type in filter on mobile
        await m_filter.fill("union")
        await asyncio.sleep(0.5)
        m_union = m_aside.locator("button:has-text('C# 15 Union Boundary')").first
        assert await m_union.is_visible(), "Union boundary item should be visible in mobile filter"

        # Capture mobile drawer screenshot
        mobile_screenshot = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images\suite-grouped-navigation-mobile.png"
        await mobile_page.screenshot(path=mobile_screenshot, full_page=False)
        print(f"PASS: Saved mobile screenshot to {mobile_screenshot}")

        await browser.close()
        print("ALL TESTS PASSED 100%!")

if __name__ == "__main__":
    asyncio.run(run())
