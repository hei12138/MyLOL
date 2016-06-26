using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MyLOL.Controls
{
    public class CommonHelper
    {
        public static IEnumerable<DependencyObject> GetVisualChildren(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return GetVisualChildrenAndSelfIterator(element).Skip<DependencyObject>(1);
        }

        public static IEnumerable<DependencyObject> GetVisualDescendants(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return GetVisualDescendantsAndSelfIterator(element).Skip<DependencyObject>(1);
        }

        private static IEnumerable<DependencyObject> GetVisualDescendantsAndSelfIterator(DependencyObject element)
        {
            Queue<DependencyObject> iteratorVariable0 = new Queue<DependencyObject>();
            iteratorVariable0.Enqueue(element);
            while (true)
            {
                if (iteratorVariable0.Count <= 0)
                {
                    yield break;
                }
                DependencyObject iteratorVariable1 = iteratorVariable0.Dequeue();
                yield return iteratorVariable1;
                foreach (DependencyObject obj2 in GetVisualChildren(iteratorVariable1))
                {
                    iteratorVariable0.Enqueue(obj2);
                }
            }
        }

        private static IEnumerable<DependencyObject> GetVisualChildrenAndSelfIterator(DependencyObject element)
        {
            yield return element;
            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
            int childIndex = 0;
            while (true)
            {
                if (childIndex >= childrenCount)
                {
                    yield break;
                }
                yield return VisualTreeHelper.GetChild(element, childIndex);
                childIndex++;
            }
        }
    }
}

