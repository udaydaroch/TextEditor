# TextEditor - Blazor Document Management System

A modern, full-featured document management application built with Blazor Server (.NET 8) that allows users to organize and manage their documents using a folder-based structure.

## 📋 Features

### Folder Management
- **Create Folders** - Organize documents into custom folders with names and descriptions
- **View Modes** - Switch between Grid (card) and List views with persistent preference
- **Delete Folders** - Remove folders (documents become unfiled)
- **Folder Counts** - See document count for each folder at a glance

### Document Management
- **Create Documents** - Write and save new documents
- **Edit Documents** - Modify existing documents
- **View Documents** - Read-only view of document content
- **Organize Documents** - Assign documents to folders or leave unfiled
- **Delete Documents** - Remove documents with confirmation
- **Document Metadata** - Track creation and last modified dates

### User Interface
- **Responsive Design** - Works on desktop, tablet, and mobile
- **Bootstrap Styling** - Modern, professional appearance
- **Bootstrap Icons** - Visual icons throughout the interface
- **Modal Dialogs** - Clean popup dialogs for creating folders
- **Hover Effects** - Interactive card animations
- **Persistent Preferences** - View mode saved to browser localStorage

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK or later
- Visual Studio 2022 or VS Code
- A modern web browser

### Installation

1. **Clone or download the project**
   ```bash
   git clone <your-repo-url>
   cd TextEditor
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open in browser**
   Navigate to `https://localhost:5001` (or the port shown in terminal)

## 📁 Project Structure

```
TextEditor/
├── Components/
│   ├── Pages/
│   │   ├── Home.razor              # Main folder view
│   │   ├── Documents.razor         # All documents list
│   │   ├── DocumentEdit.razor      # Create/Edit documents
│   │   ├── DocumentView.razor      # View document (read-only)
│   │   ├── FolderView.razor        # Documents in a folder
│   │   └── UnfiledDocuments.razor  # Unfiled documents list
│   ├── Layout/
│   │   ├── MainLayout.razor        # Main app layout
│   │   └── NavMenu.razor           # Navigation menu
│   └── App.razor                   # Root component
├── Models/
│   ├── Document.cs                 # Document model
│   └── Folder.cs                   # Folder model
├── Services/
│   ├── DocumentService.cs          # Document business logic
│   └── FolderService.cs            # Folder business logic
├── wwwroot/                        # Static files
└── Program.cs                      # App configuration
```

## 🎯 Usage Guide

### Creating a Folder

1. Click the **"New Folder"** button on the home page
2. Enter a folder name (required)
3. Optionally add a description
4. Click **"Create Folder"**
5. The folder appears in your chosen view mode

### Creating a Document

1. Click **"New Document"** from the home page or within a folder
2. Optionally select a folder from the dropdown
3. Enter a title (required)
4. Write your content in the text area
5. Click **"Save"**

### Organizing Documents

- **Assign to Folder**: Edit a document and select a folder from the dropdown
- **Unfiled Documents**: Documents without a folder appear in the "Unfiled Documents" section
- **Move Between Folders**: Edit a document and change its folder selection

### Viewing Modes

- **Grid View**: Visual card layout with folder icons
- **List View**: Compact horizontal list layout
- Click the Grid/List toggle buttons to switch
- Your preference is automatically saved

## 🛠️ Technical Details

### Technologies Used
- **Framework**: Blazor Server (.NET 8)
- **UI**: Bootstrap 5
- **Icons**: Bootstrap Icons
- **Interactivity**: Interactive Server render mode
- **Storage**: In-memory (easily extendable to database)

### Key Components

#### Services
- `IDocumentService` / `DocumentService` - Manages document operations (CRUD)
- `IFolderService` / `FolderService` - Manages folder operations (CRUD)

Both services are registered as **Singletons** in `Program.cs`:
```csharp
builder.Services.AddSingleton<IDocumentService, DocumentService>();
builder.Services.AddSingleton<IFolderService, FolderService>();
```

#### Models
- `Document` - Title, Content, Created/Modified dates, FolderId
- `Folder` - Name, Description, Created date, DocumentCount

### Data Persistence

Currently uses **in-memory storage** (data resets on app restart). 

To add database persistence:
1. Install Entity Framework Core
2. Create a DbContext
3. Update services to use the database
4. Add migrations and update the database

Example with SQLite:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## 🎨 Customization

### Changing Colors
Edit the folder icon colors in `Home.razor`:
```razor
<i class="bi bi-folder-fill" style="font-size: 3rem; color: #ffc107;"></i>
```

### Adding New Features
1. Create new models in `Models/`
2. Add service methods in `Services/`
3. Create new pages in `Components/Pages/`
4. Update navigation in `NavMenu.razor`

## 📝 Future Enhancements

Potential features to add:
- [ ] Database persistence (SQL Server, SQLite, etc.)
- [ ] Search functionality
- [ ] Document tags/categories
- [ ] Rich text editing
- [ ] Document sharing
- [ ] Export to PDF/Word
- [ ] User authentication
- [ ] Document versioning
- [ ] Nested folders
- [ ] Drag-and-drop organization

## 🐛 Known Issues

- Data is stored in-memory and will be lost on application restart
- No authentication/authorization (single-user application)
- No rich text formatting (plain text only)

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📞 Support

If you have questions or run into issues:
- Open an issue on GitHub
- Check existing issues for solutions
- Review the Blazor documentation at https://docs.microsoft.com/aspnet/core/blazor

## 🙏 Acknowledgments

- Built with [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- Styled with [Bootstrap 5](https://getbootstrap.com/)
- Icons from [Bootstrap Icons](https://icons.getbootstrap.com/)

---

**Version**: 1.0.0  
**Last Updated**: January 2026  
**Author**: Your Name

Made with ❤️ using Blazor
