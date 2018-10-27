# SMSTTPS

## DNS Service

1. Acts as a central source for domain registration
2. Translates domains into phone numbers
3. Checks is a host is alive

### REG Request

Registers a domain against a number with the DNS service.

The senders number is stored as the host for the given domain.

```
REG <domain>

REG fluffyalpacas
```

#### Responses

Success
```
OK
```

Already Registered
```
CONFLICT
```

### GET Request

Requests the host phone number for a given domain

```
GET <DOMAIN>

GET fluffyalpacas
```

#### Responses

Success

```
OK <HOSTPHONENUMBER>

OK 07879999999
```

Domain not found

```
NOTFOUND
```

## Host

1. Responds to GET requets for content

### GET request

Requests a resource from a Host.

The sender is assumed to be the device requesting the resource, so the host will respond using the number of the sender.

```
GET <RESOURCENAME> <SESSIONID> <CONTENTTYPE>

GET alpacas        A7          0
```

#### Responses

Success

```
OK <PACKETHEADER> <CONTENT>

OK A7010901       Alpacas are very fluffy and lovable
```

Content Not Found

```
NOTFOUND
```

## Protocol Defintions

### Packet Header

1. Session ID - 8 bits
2. Frame Number - 8 bits
3. Total Frames - 8 bits
4. Content Flags - 8 bits

#### Session ID

- Randomly generated number between 0 and 255.
- Uniquely identifies a request to prevent stray messages causing issues
- Sent with the GET request, and included in each response frame.

#### Frame Number

- Used to determine the order that that packets should be reconsteructed in
- Starts at 0 and increments by one for each frame to a maximum of 255
- Sent in each response frame

#### Total Frames

- Used to tell the client how many frames to expect for a complete response
- Valid range 1 - 255
- Sent with each response frame

#### Content Flags

- 8 bits sent with each content frame
- Each bit is a binary flag describing the content

##### Bits

1. Content Type - 0 = plain text, 1 = markup
2. unused
3. unused
4. unused
5. unused
6. unused
7. unused
8. unused
