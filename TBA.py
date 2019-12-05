import requests
import json


# Contains Basic Methods For Querying the Blue Alliance Data
api_url = "https://www.thebluealliance.com/api/v3"
auth_key = "0Ws8VJsYtWRYmN6CQwahhtiM0vP4pl83J23Lpf4AqsdwmoLmRU7DkXYGDPTGUBWk"


# Returns a list of Event Keys for a given year
def get_year_events(year):
    r = make_tba_request("/events/{year}".format(year = year),"")
    events = []
    for row in r.json():
        name = str(row["short_name"])
        code = str(row["first_event_code"]).lower()
        if len(name)>0 and len(code)> 0 and code is not "none":
            events.append(name +" - "+str(year)+code)
    return events

#Requests an update on an entry from TBA, returns the updated entry. If no update occurs returns the original entry.
def update_entry(request,entry, last_update):
    r = make_tba_request(request,last_update)
    last_update = r.headers["Last-Modified"]
    if r.status_code == 200:
        entry = r.json()
    return entry, last_update

#Helper method to add headers tfo request
def make_tba_request(key_string, last_modified):
    header = {"X-TBA-Auth-Key":auth_key,"If-Modified-Since":last_modified}
    r = requests.get(api_url+key_string, headers=header)  
    return r

def check_tba_new_data(request, last_modified):
    r = make_tba_request(request,last_modified)
    return not(r.status_code == 304)

def check_tba_connection():
    try:
        make_tba_request(api_url,"")
        return True
    except:
        return False

