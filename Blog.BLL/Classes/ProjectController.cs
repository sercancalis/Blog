using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class ProjectController
    {
        ProjectDAL projectDAL;
        public ProjectController()
        {
            projectDAL = new ProjectDAL();
        }

        public List<Project> GetAllProjects()
        {
            return projectDAL.GetAll();
        }

        public bool DeleteProject(int id)
        {
            return projectDAL.Delete(projectDAL.GetByID(id)) > 0; 
        }
        
        public bool AddProject(Project project, byte[] image,int[] tags)
        {
            project.CreatedDate = DateTime.Now;
            project.ModifiedDate = DateTime.Now;
            project.Image = image;
            project.TagDetails = new List<TagDetail>();
            foreach (var item in tags)
            {
                project.TagDetails.Add(new TagDetail() { TagID = item });
            }

            return projectDAL.Add(project) > 0; 
        }

        public Project GetProject(int ID)
        {
            return projectDAL.GetByID(ID);
        }

        public bool UpdateProject(Project project,int[] tags)
        {
            Project oldproject = GetProject(project.ID);
            if (project.Image == null)
                project.Image = oldproject.Image;
            project.ModifiedDate = DateTime.Now;
            oldproject.TagDetails.Clear();
            foreach (var item in tags)
            {
                oldproject.TagDetails.Add(new TagDetail() { TagID = item });
            } 
            return projectDAL.Update(project) > 0;
        }
     
    }
}
