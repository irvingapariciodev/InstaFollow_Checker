# InstaFollow Checker

Web application that analyzes Instagram follower data to identify accounts that do not follow you back.

The application processes JSON files exported from Instagram and generates insights such as total followers, total following, and users that do not follow back.

---

# Project Overview

InstaFollow Checker is a web application built with .NET using Clean Architecture principles.

The system allows users to upload follower and following JSON files exported from Instagram and analyzes the relationship between the two lists.

The result is presented through a dashboard displaying key metrics and a detailed list of accounts that do not follow back.

---

# Key Features

- Upload followers.json and following.json files
- Parse and process Instagram JSON data
- Identify accounts that do not follow back
- Display follower statistics
- Dashboard with analysis metrics
- Web interface for file upload and visualization

---

# Technology Stack

Backend
- .NET
- ASP.NET Core Web API

Architecture
- Clean Architecture

Frontend
- ASP.NET Web App / MVC

Data Processing
- JSON parsing

Version Control
- Git
- GitHub

---

# System Architecture

The project follows Clean Architecture principles to ensure separation of concerns and maintainability.

Layers:

Domain  
Contains core entities and business rules.

Application  
Contains use cases and business logic.

Infrastructure  
Handles external dependencies such as JSON parsing.

API  
Exposes endpoints and connects the system to the user interface.

Architecture flow:

Request  
Controller  
Application Service  
Domain Logic  
Infrastructure Services  
Response

---

# Agile Project Planning

The development of InstaFollow Checker follows an Agile methodology using a Kanban workflow to organize tasks and track progress.

The project is divided into two development sprints with a daily development capacity of one hour.

Project timeline:

Start date: March 15  
End date: April 15  
Total development time: 30 hours

## Sprint Structure

The project is divided into two sprints.

Sprint 1 – API Development  
Focus on building the backend API using .NET and implementing the follower analysis logic.

Sprint 2 – Web Application  
Focus on building the web interface and integrating it with the API to display analysis results.

## Kanban Workflow

The development workflow follows a Kanban board structure hosted in GitHub Projects.

Workflow stages:

Backlog  
Tasks that are planned but not yet ready to start.

Ready  
Tasks that are defined and ready to begin.

In Progress  
Tasks currently under development.

Review  
Tasks completed but pending verification.

Done  
Tasks that have been completed.


Backlog → Ready → In Progress → Review → Done

## Sprint Milestones

Sprint 1 – API Development  
Start: March 15  
End: March 29

Main deliverables:

- Clean Architecture solution structure
- JSON parsing service
- Followers vs following comparison algorithm
- API endpoint for analysis
- Metrics generation

Sprint 2 – Web Application  
Start: March 30  
End: April 15

Main deliverables:

- Web interface for file upload
- Integration with API
- Dashboard with follower metrics
- Non-followers user list
- Final documentation