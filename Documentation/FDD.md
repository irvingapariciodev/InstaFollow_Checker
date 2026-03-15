# Functional Diagram Document (FDD)

## Project: InstaFollow_Checker

---

# 1. System Purpose

InstaFollow_Checker is a web application that analyzes follower data exported from Instagram.

The system compares two lists:

* Accounts that follow the user
* Accounts that the user follows

The application identifies which accounts **do not follow the user back** and displays the results in a simple dashboard.

---

# 2. Functional Overview

The system allows the user to upload two JSON files exported from Instagram.
Once uploaded, the system processes the data, compares the lists, and displays the analysis results.

---

# 3. Functional Flow

```
User
  │
  ▼
Upload Instagram files
  │
  ▼
System reads file data
  │
  ▼
System compares follower lists
  │
  ▼
System identifies non-followers
  │
  ▼
Dashboard displays results
```

---

# 4. System Inputs

The user must upload two files exported from Instagram:

### Followers file

Contains the list of accounts that follow the user.

### Following file

Contains the list of accounts that the user follows.

These files are used to perform the comparison.

---

# 5. System Process

After the user uploads the files, the system performs the following steps:

1. Read the data from both JSON files
2. Extract usernames from each list
3. Compare the followers and following lists
4. Identify accounts that do not follow the user back

---

# 6. System Outputs

The application generates a dashboard that displays:

### Metrics

* Total number of followers
* Total number of accounts followed
* Total number of accounts that do not follow back

### Non-Followers List

A list of usernames that the user follows but who **do not follow back**.

Example:

```
Followers: 1200
Following: 980
Non-followers: 145
```

Example list:

```
user_a
user_b
user_c
user_d
```

---

# 7. Functional Diagram

```
Upload Files
     │
     ▼
Read JSON Data
     │
     ▼
Extract Usernames
     │
     ▼
Compare Followers vs Following
     │
     ▼
Identify Non-Followers
     │
     ▼
Display Dashboard
```

---

# 8. Expected Result

The user can easily identify which accounts do not follow them back and view basic statistics about their followers and following lists.

---

# 9. Future Improvements

Possible future enhancements:

* Export results to CSV
* Filter non-followers
* Sort users alphabetically
* Add follower growth analysis
* Support additional Instagram export formats

---

# 10. Related Documentation

Additional documentation for the project:

* README.md
* Agile Project Planning