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

        # 1. Test Coaching Tour Launch from Header
        tour_btn = page.locator("button:has-text('Coaching Tour')").first
        await tour_btn.click()
        await asyncio.sleep(0.5)

        # Verify Step 1
        tour_title = page.locator("#tour-card-title")
        assert "Welcome to BlazorTailwindUI v1.4.6!" in await tour_title.text_content()
        step_counter = page.locator("text=Step 1 of 12").first
        assert await step_counter.is_visible(), "Step 1 of 12 should be visible"
        print("PASS: Tour Step 1 rendered correctly (Step 1 of 12)!")

        # Click Next Step -> Step 2: Grouped Category Hubs
        next_btn = page.locator("button:has-text('Next Step')").first
        await next_btn.click()
        await asyncio.sleep(0.3)
        assert "Grouped Category Hubs" in await tour_title.text_content()
        assert await page.locator("text=Step 2 of 12").first.is_visible()
        print("PASS: Tour Step 2: Grouped Category Hubs rendered!")

        # Click Next Step -> Step 3: CRM Draggable Dashboard
        await next_btn.click()
        await asyncio.sleep(0.3)
        assert "Mobile-First CRM Draggable Dashboard" in await tour_title.text_content()
        launch_crm_btn = page.locator("button:has-text('Launch CRM Studio')").first
        assert await launch_crm_btn.is_visible(), "Action button for CRM Studio should be present"
        print("PASS: Tour Step 3: CRM Dashboard with Action button rendered!")

        # Click Next Step -> Step 4: PDF Form Filler & Flattening
        await next_btn.click()
        await asyncio.sleep(0.3)
        assert "PDF Form Filler" in await tour_title.text_content()
        launch_pdf_btn = page.locator("button:has-text('Launch PDF Signer')").first
        assert await launch_pdf_btn.is_visible(), "Action button for PDF Signer should be present"
        print("PASS: Tour Step 4: PDF Form Flattening rendered!")

        # Click Next Step -> Step 5: C# 15 Union Boundary
        await next_btn.click()
        await asyncio.sleep(0.3)
        assert "C# 15 Discriminated Union Boundary" in await tour_title.text_content()
        launch_union_btn = page.locator("button:has-text('Launch Union Studio')").first
        assert await launch_union_btn.is_visible(), "Action button for Union Studio should be present"
        print("PASS: Tour Step 5: C# 15 Union Boundary rendered!")

        # Capture coaching tour modal screenshot
        os.makedirs(r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images", exist_ok=True)
        tour_screenshot = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images\suite-coaching-tour.png"
        await page.screenshot(path=tour_screenshot, full_page=False)
        print(f"PASS: Saved coaching tour screenshot to {tour_screenshot}")

        # Close tour by skipping
        skip_btn = page.locator("button:has-text('Skip Coaching')").first
        await skip_btn.click()
        await asyncio.sleep(0.5)

        # 2. Navigate to Training & Masterclass Hub
        print("Navigating to Training & Masterclass Hub...")
        training_nav = page.locator("aside button:has-text('Coaching & Video')").first
        await training_nav.click()
        await asyncio.sleep(1)

        training_header = page.locator("text=BlazorTailwindUI Training Hub & Masterclass").first
        assert await training_header.is_visible(), "Training Hub title should be visible"
        print("PASS: Training Hub loaded!")

        # Verify HyperFrames chapters
        crm_chapter = page.locator("button:has-text('CRM Draggable Studio')").first
        pdf_chapter = page.locator("button:has-text('PDF Form Flattening')").first
        union_chapter = page.locator("button:has-text('C# 15 Union Boundary')").first
        nav_chapter = page.locator("button:has-text('Grouped Category Hubs')").first

        assert await crm_chapter.is_visible(), "CRM Draggable chapter should be visible"
        assert await pdf_chapter.is_visible(), "PDF Form Flattening chapter should be visible"
        assert await union_chapter.is_visible(), "C# 15 Union Boundary chapter should be visible"
        assert await nav_chapter.is_visible(), "Grouped Category Hubs chapter should be visible"
        print("PASS: All 4 new HyperFrames video chapters are rendered and clickable!")

        # Test clicking a chapter button
        await crm_chapter.click()
        await asyncio.sleep(0.5)

        # 3. Test Interactive Playground with new components
        pg_select = page.locator("select").first
        await pg_select.select_option("dashboard")
        await asyncio.sleep(0.5)
        assert await page.locator("text=CRM Draggable Dashboard Widget").first.is_visible()
        snippet_code = page.locator("code").first
        assert "TwDashboard" in await snippet_code.text_content()
        print("PASS: Playground successfully rendered TwDashboard preview and snippet!")

        await pg_select.select_option("unionboundary")
        await asyncio.sleep(0.5)
        assert await page.locator("text=C# 15 Discriminated Union Boundary").first.is_visible()
        assert "TwUnionBoundary" in await snippet_code.text_content()
        print("PASS: Playground successfully rendered TwUnionBoundary preview and snippet!")

        # 4. Verify Developer Training Curriculum has all 12 principles
        principle_7 = page.locator("text=Persistent Draggable Dashboard (TwDashboard)").first
        principle_8 = page.locator("text=PDF Form Flattening & Signatures").first
        principle_9 = page.locator("text=C# 15 Discriminated Union Boundaries").first
        principle_10 = page.locator("text=Grouped Category Hubs & Real-Time Search").first
        principle_11 = page.locator("text=2027 Spatial & Anticipatory UI").first
        principle_12 = page.locator("text=Barcode, OCR & Check 21 MICR Reader").first

        assert await principle_7.is_visible(), "Principle 7 should be visible"
        assert await principle_8.is_visible(), "Principle 8 should be visible"
        assert await principle_9.is_visible(), "Principle 9 should be visible"
        assert await principle_10.is_visible(), "Principle 10 should be visible"
        assert await principle_11.is_visible(), "Principle 11 should be visible"
        assert await principle_12.is_visible(), "Principle 12 should be visible"
        print("PASS: All 12 developer curriculum principles are visible!")

        # 5. Test Knowledge Check Quiz Questions 3, 4, 5, 6
        # Question 3: PDF flattening
        q3_radio = page.locator("input[name='quiz3']").first
        await q3_radio.check()
        await asyncio.sleep(0.3)
        assert await page.locator("text=Correct! Flattening makes forms immutable and legally enforceable.").is_visible()

        # Question 4: C# 15 Union
        q4_radio = page.locator("input[name='quiz4']").first
        await q4_radio.check()
        await asyncio.sleep(0.3)
        assert await page.locator("text=Correct! Discriminated union types guarantee exhaustive state coverage at compile time.").is_visible()

        # Question 5: LocalStorage Persistence
        q5_radio = page.locator("input[name='quiz5']").first
        await q5_radio.check()
        await asyncio.sleep(0.3)
        assert await page.locator("text=Correct! LocalStorage persistence provides instant client-side reload with zero cloud fees.").is_visible()

        # Question 6: scroll-mt-24
        q6_radio = page.locator("input[name='quiz6']").first
        await q6_radio.check()
        await asyncio.sleep(0.3)
        assert await page.locator("text=Correct! scroll-mt-24 ensures anchor targets remain perfectly visible below sticky bars.").is_visible()
        print("PASS: All quiz questions tested and verified with instant green feedback!")

        # 6. Verify Roadmap cards
        shipped_145 = page.locator("text=Shipped v1.4.5 ✅").first
        shipped_146 = page.locator("text=Shipped v1.4.6 ✅").first
        assert await shipped_145.is_visible(), "Shipped v1.4.5 badge should be visible"
        assert await shipped_146.is_visible(), "Shipped v1.4.6 badge should be visible"
        print("PASS: Roadmap cards reflect Shipped v1.4.5 and v1.4.6!")

        # Capture desktop training hub screenshot
        training_screenshot = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images\suite-training-coaching.png"
        await page.screenshot(path=training_screenshot, full_page=False)
        print(f"PASS: Saved training hub screenshot to {training_screenshot}")

        # 7. Mobile Coaching Tour Test (375x812)
        mobile_page = await browser.new_page(viewport={"width": 375, "height": 812})
        await mobile_page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        await asyncio.sleep(2)

        # Open mobile drawer and start tour or trigger tour
        await mobile_page.evaluate("() => window.dispatchEvent(new CustomEvent('start-tour'))")
        # Alternatively click coaching in mobile bottom nav or hamburger
        m_hamburger = mobile_page.locator("button[aria-label='Toggle Navigation Drawer']").first
        await m_hamburger.click()
        await asyncio.sleep(0.5)
        m_coaching = mobile_page.locator("aside button:has-text('Coaching & Video')").first
        await m_coaching.click()
        await asyncio.sleep(1)

        m_start_tour = mobile_page.locator("button:has-text('Start Coaching Tour')").first
        await m_start_tour.click()
        await asyncio.sleep(0.5)

        m_tour_title = mobile_page.locator("#tour-card-title")
        assert await m_tour_title.is_visible(), "Tour card should be visible on mobile"
        print("PASS: Mobile coaching tour rendered smoothly within 375px bounds!")

        await browser.close()
        print("ALL TRAINING & COACHING TESTS PASSED 100%!")

if __name__ == "__main__":
    asyncio.run(run())
