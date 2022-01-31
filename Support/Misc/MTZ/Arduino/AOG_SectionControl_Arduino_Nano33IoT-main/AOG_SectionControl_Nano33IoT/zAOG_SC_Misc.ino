//-------------------------------------------------------------------------------------------------
//8. März 2020

void WiFi_LED_blink(byte blkSpeed)   
{
	unsigned long currentTime = millis();
	if (!LED_WIFI_ON) {
		if (currentTime > (LED_WIFI_time + (LED_WIFI_pause >> blkSpeed))) {
			LED_WIFI_time = currentTime;
			LED_WIFI_ON = true;
			digitalWrite(LED_BUILTIN, HIGH);
			digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
		}
	}
	if (LED_WIFI_ON) {
		if (currentTime > (LED_WIFI_time + (LED_WIFI_pulse >> blkSpeed))) {
			LED_WIFI_time = currentTime;
			LED_WIFI_ON = false;
			digitalWrite(LED_BUILTIN, LOW);
			digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);
		}
	}
}

/*
//-------------------------------------------------------------------------------------------------
//9. Maerz 2021

void WiFi_LED_blink(void* pvParameters)
{
	unsigned long now;
	byte blkSpeed;
		now = millis();

		if (WiFi_connect_step > 0) { blkSpeed = 2; }
		else {
			if (now > (DataFromAOGTime + 1000L)) {
				if ((SectAuto) && (DataFromAOGTime != 0)) { blkSpeed = 3; }
				else { blkSpeed = 0; }
			}
			else { //all OK = LED on
				vTaskDelay(800);
				blkSpeed = 255;
				LED_WIFI_ON = true;
				digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
#if useLED_BUILTIN
				digitalWrite(LED_BUILTIN, HIGH);
#endif
			}
		}

		if (blkSpeed != 255) {
			if (!LED_WIFI_ON) {
				LED_WIFI_time = now;
				LED_WIFI_ON = true;
#if useLED_BUILTIN
				digitalWrite(LED_BUILTIN, HIGH);
#endif
				digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);

				vTaskDelay(LED_WIFI_pause >> blkSpeed);

			}
			if (LED_WIFI_ON) {
				LED_WIFI_time = now;
				LED_WIFI_ON = false;
#if useLED_BUILTIN
				digitalWrite(LED_BUILTIN, LOW);
#endif
				digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);

				vTaskDelay(LED_WIFI_pulse >> blkSpeed);
			}
		}
	}
}
*/