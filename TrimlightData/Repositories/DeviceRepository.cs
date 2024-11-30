using TrimlightData.Models;

namespace TrimlightData.Repositories;
public class DeviceRepository : BaseRepository
{
    const string DEVICE_LIST_ENDPOINT = "devices";
    const string DEVICE_DETAILS_ENDPOINT = "device/get";
    const string DEVICE_UPDATE_ENDPOINT = "device/update";
    const string EFFECT_PREVIEW_ENDPOINT = "device/effect/preview";
    const string EFFECT_SAVE_ENDPOINT = "device/effect/save";
    const string EFFECT_VIEW_ENDPOINT = "device/effect/view";
    const string EFFECT_DELETE_ENDPOINT = "device/effect/delete";
    const string DAILY_SCHEDULE_SAVE_ENDPOINT = "device/schedule/daily/save";
    const string CALENDAR_SCHEDULE_SAVE_ENDPOINT = "device/schedule/calendar/save";
    const string CALENDAR_SCHEDULE_DELETE_ENDPOINT = "device/schedule/calendar/delete";
    const string COMBINED_EFFECT_SAVE_ENDPOINT = "device/combined-effect/save";
    const string SHADOW_UPDATE_ENDPOINT = "device/notify-update-shadow";
    const string OVERLAY_EFFECT_UPDATE_ENDPOINT = "device/effect/overlay";
    const string DEVICE_DATETIME_UPDATE_ENDPOINT = "device/datetime/sync";

    public DeviceRepository(string clientId, string clientSecret) : base(clientId, clientSecret)
    {
    }

    public async Task<Device[]> GetDevicesAsync()
    {
        return await GetTrimlightDataAsync<Device[]>(DEVICE_LIST_ENDPOINT);
    }

    public async Task<DeviceDetails> GetDeviceAsync(string deviceId)
    {
        var request = new
        {
            DeviceId = deviceId,
            CurrentDate = DateTime.Now.ToTrimlightDateTime()
        };

        return await PostTrimlightDataAsync<DeviceDetails>(DEVICE_DETAILS_ENDPOINT, request);
    }

    public async Task SetDeviceSwitchStateAsync(string deviceId, SwitchState switchState)
    {
        var request = new
        {
            DeviceId = deviceId,
            Payload = new
            {
                SwitchState = switchState
            }
        };

        await PostTrimlightDataAsync(DEVICE_UPDATE_ENDPOINT, request);
    }

    public async Task SetDeviceNameAsync(string deviceId, string name)
    {
        var request = new
        {
            DeviceId = deviceId,
            Payload = new
            {
                Name = name
            }
        };

        await PostTrimlightDataAsync(DEVICE_UPDATE_ENDPOINT, request);
    }

    public async Task SetDeviceColorOrderAsync(string deviceId, ColorOrder colorOrder)
    {
        var request = new
        {
            DeviceId = deviceId,
            Payload = new
            {
                ColorOrder = colorOrder
            }
        };

        await PostTrimlightDataAsync(DEVICE_UPDATE_ENDPOINT, request);
    }

    public async Task SetDeviceIcAsync(string deviceId, Ic ic)
    {
        var request = new
        {
            DeviceId = deviceId,
            Payload = new
            {
                Ic = ic
            }
        };

        await PostTrimlightDataAsync(DEVICE_UPDATE_ENDPOINT, request);
    }

    public void SetDevicePorts(string deviceId, Port[] ports)
    {
        throw new NotImplementedException();
    }

    public void PreviewBuiltInEffect(string deviceId, Effect effect)
    {
        throw new NotImplementedException();
    }

    public void PreviewCustomEffect(string deviceId, Effect effect)
    {
        throw new NotImplementedException();
    }

    public void SaveEffect(string deviceId, Effect effect)
    {
        throw new NotImplementedException();
    }

    public void ViewEffect(string deviceId, int effectId)
    {
        throw new NotImplementedException();
    }

    public void DeleteEffect(string deviceId, int effectId)
    {
        throw new NotImplementedException();
    }

    public void SaveDailySchedule(string deviceId, DailySchedule daily)
    {
        throw new NotImplementedException();
    }

    public int SaveCalendarSchedule(string deviceId, CalendarSchedule calendar)
    {
        throw new NotImplementedException();
    }

    public void DeleteCalendarSchedule(string deviceId, int calendarId)
    {
        throw new NotImplementedException();
    }

    public void SaveCombinedEffect(string deviceId, CombinedEffect effect)
    {
        throw new NotImplementedException();
    }

    public void NotifyUpdateShadow(string deviceId)
    {
        throw new NotImplementedException();
    }

    public void UpdateOverlayEffects(string deviceId, OverlayEffect[] effects)
    {
        throw new NotImplementedException();
    }

    public void SetDeviceDateTime(string deviceId, TrimlightDateTime datetime)
    {
        throw new NotImplementedException();
    }
}
